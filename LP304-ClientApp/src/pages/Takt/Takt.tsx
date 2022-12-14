import './Takt.css';
import { useEffect, useState } from "react";
import useMqttConnection from '../../hooks/mqtt/useMqttConnection';
import FormInput from '../../components/forminput/FormInput';
import useFetch from '../../hooks/db/useFetch';
import Station from '../../models/db/Stations';

function Home() {
    const [isStarted, setIsStarted] = useState(window.sessionStorage.getItem("taktStarted"));
    const [stations, setStations] = useState<Station[] | Array<Station>>([]);
    const [opacity, setOpacity] = useState(1);

    const [taktTime, setTaktTime] = useState<number>(0);
    const [values, setValues] = useState<any>({
        taktTime: "",
        OrderQuantity: "",
        taktEfficiency: "",
        repeatTakt: false
    });

    const { mqttConnect, mqttPublish, mqttSub, mqttUnSub, mqttStatus, mqttPayload } = useMqttConnection({ host: "172.17.10.129", port: "1884" });
    const { fetchEntity, data, isPending } = useFetch();

    useEffect(() => {
        fetchEntity('https://localhost:7112/api/station')

        setStations(data || [])
    }, [isPending])

    useEffect(() => {
        if (mqttPayload?.message === "true") {
            window.sessionStorage.setItem("taktStarted", mqttPayload?.message)
            setIsStarted("true")
        } else {
            setTaktTime(mqttPayload?.message)
        }
    }, [mqttPayload])

    const inputs = [
        {
            id: 1,
            name: "taktTime",
            type: "number",
            placeholder: "Takt time",
            pattern: "[0-9]{1,5}$",
            min: 0,
            errorMessage: "Number is required, can't be longer than 5 numbers and can't start with 0!",
            label: "Takt time",
        },
        {
            id: 2,
            name: "OrderQuantity",
            type: "number",
            placeholder: "Parts to produce",
            pattern: "[0-9]{1,5}$",
            min: 0,
            errorMessage: "Number is required, can't be longer than 5 numbers and can't start with 0!",
            label: "Number of parts",
        }, {
            id: 3,
            name: "taktEfficiency",
            type: "number",
            placeholder: "Efficiency %",
            min: 0,
            max: 100,
            errorMessage: "Number is required, can't be longer than 5 numbers and can't start with 0!",
            label: "Takt efficiency",
        },
        {
            id: 4,
            name: "repeatTakt",
            type: "checkbox",
            placeholder: "Repeat takt",
            label: "Repeat takt"
        }
    ]

    const handleSubmit = (e: any) => {
        e.preventDefault();
    }

    const onChange = (e: any) => {
        setValues(
            e.target.type === "checkbox" ?
                { ...values, [e.target.name]: e.target.checked } :
                { ...values, [e.target.name]: parseInt(e.target.value) })
        mqttConnect()
    }

    const publishStart = () => {
        mqttPublish({ topic: "from/lp304-takt/webclient/requesttakt", qos: 0, payload: JSON.stringify(values) })
        mqttSub({ topic: "from/lp304-takt/taktclient/taktstart", qos: 2 })
        mqttSub({ topic: "from/lp304-takt/taktclient/taktTimeAcc", qos: 2 })
    }

    const stopTakt = () => {
        mqttUnSub({ topic: "from/lp304-takt/taktclient/taktstart", qos: 2 })
        mqttUnSub({ topic: "from/lp304-takt/taktclient/taktTimeAcc", qos: 2 })
        setIsStarted("false")
        setTaktTime(0)
        window.sessionStorage.removeItem("taktStarted")
    }

    const handleStation = (station: Station) => {
        setStations(stations.map((s) => 
        s.id === station.id ? {...s, active: !s.active} : s))
    }

    return (
        <main>
            <div className="main-content">
                <div className="main-header">
                    <h2>Takt</h2>
                    <p>Here you can configure and start the Takt</p>
                </div>
                <div className="takt-content">

                    {isStarted !== "true" ? (
                        <form onSubmit={handleSubmit}>
                            <h2>Configure and start Takt</h2>
                            <div className="station-container">
                        {stations?.map(station => (
                            <div key={station.id}
                                className="station-content"
                                style={{opacity: station.active ? 1 : 0.5}}
                                onClick={(() => handleStation(station))}>
                                <p>{station.name}</p>
                            </div>
                        ))}
                    </div>
                            <div>
                                {inputs.map(input => (
                                    <FormInput key={input.id} {...input} value={values[input.name]} onChange={onChange} />
                                ))}
                                <button type="button" onClick={publishStart}>Start cycle</button>
                            </div>
                        </form>
                    ) : (
                        <div>
                            {taktTime}
                            <button onClick={stopTakt}>hej</button>
                        </div>
                    )}
                </div>
            </div>
        </main>
    );
}

export default Home;