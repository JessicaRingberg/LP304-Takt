import React, { useEffect, useState } from 'react';
import MqttHost from '../../../models/mqtt/MqttHost';
import useMqttConnection from '../../../hooks/mqtt/useMqttConnection';
import './MqttConnection.css'
import FormInput from '../../../components/forminput/FormInput';
import { useMessageContext } from '../../../hooks/db/useMessageContext';

const MqttConnection: React.FC = () => {
    const { dispatch } = useMessageContext()
    const [buttonText, setButtonText] = useState<string>("Test connection");
    const [style, setStyle] = useState<Object>();
    const [values, setValues] = useState<MqttHost | any>({
        host: "",
        port: "",
        clientId: "",
        username: "",
        password: ""
    });

    const { mqttStatus, mqttConnect } = useMqttConnection(values);

    useEffect(() => {
        if (mqttStatus?.status === "Connected") {
            setStyle({
                backgroundColor: '#41af8c'
            });
            dispatch({ type: "SUCCESS", message: "Connected to MQTT" })
            setButtonText("Connected");
        } else if (mqttStatus?.status === "Offline") {
            setStyle({
                backgroundColor: 'salmon'
            });
            setButtonText("Not connected");
            dispatch({ type: "ERROR", message: "Could not connect to MQTT" })
        } else if (mqttStatus?.status === "Connecting") {
            setStyle({
                backgroundColor: '#d5ae48'
            });
            setButtonText("Connecting");
        }

    }, [mqttStatus?.status, dispatch])

    const inputs = [
        {
            id: 1,
            name: "host",
            type: "text",
            placeholder: "Host",
            pattern: "[0-9.]{1,15}$",
            errorMessage: "It should be numbers and dots and not longer than 15!",
            label: "Host",
        },
        {
            id: 2,
            name: "port",
            type: "number",
            placeholder: "Port",
            errorMessage: "Port should only be number!",
            label: "Port"
        },
        {
            id: 3,
            name: "clientId",
            type: "text",
            placeholder: "Client id",
            errorMessage: "Password should be 8-20 characters and include atleast 1 letter, 1 number and 1 special character!",
            label: "Client id"
        },
        {
            id: 4,
            name: "username",
            type: "text",
            placeholder: "Username",
            errorMessage: "Password should be 8-20 characters and include atleast 1 letter, 1 number and 1 special character!",
            label: "Username"
        },
        {
            id: 5,
            name: "password",
            type: "password",
            placeholder: "Password",
            errorMessage: "Password should be 8-20 characters and include atleast 1 letter, 1 number and 1 special character!",
            label: "Password"
        }
    ]

    const handleSubmit = (e: any) => {
        e.preventDefault();
    }

    const onChange = (e: any) => {
        setValues({ ...values, [e.target.name]: e.target.value })
        // setMqttHost({ ...mqttHost, [e.target.name]: e.target.value})
        // setOptions({ ...options, [e.target.name]: e.target.value})
    }

    return (
        <main>
            <div className="main-content">
                <div className="main-header">
                    <h2>Events</h2>
                    <p>Here you can configure and start the Takt</p>
                </div>
                <div className="mqtt-connect-content">
                    <form onSubmit={handleSubmit}>
                        <h2>Change Mqtt connection</h2>
                        <div>
                            {inputs.map(input => (
                                <FormInput key={input.id} {...input} value={values[input.name]} onChange={onChange} />
                            ))}
                            <div className="button-container">
                                <button type="button">Save</button>
                                <button
                                    type="submit"
                                    onClick={mqttConnect}
                                    style={style}
                                >{buttonText}</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </main>
    );
}



export default MqttConnection;