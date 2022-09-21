import './Takt.css';
import { useState } from "react";
import UseMqttConnection from '../../hooks/mqtt/UseMqttConnection';
import FormInput from '../../components/forminput/FormInput';


function Home() {
    const [values, setValues] = useState<any>({
        taktTime: "",
        OrderQuantity: "",
        taktEfficiency: "",
        repeatTakt: false
    });

    const { mqttConnect, mqttPublish } = UseMqttConnection({ host: "172.17.10.129", port: "1884" });

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
    }

    return (
        <main>
            <div className="main-content">
                <div className="main-header">
                    <h2>Takt</h2>
                    <p>Here you can configure and start the Takt</p>
                </div>
                <div className="takt-content">
                    <form onSubmit={handleSubmit}>
                        <h2>Configure and start Takt</h2>
                        <div>
                            {inputs.map(input => (
                                <FormInput key={input.id} {...input} value={values[input.name]} onChange={onChange} />
                            ))}
                            <button type="button" onClick={publishStart}>Start cycle</button>
                        </div>
                    </form>
                </div>
            </div>
        </main>
    );
}

export default Home;