import React, { useEffect, useState } from 'react';
import MqttHost from '../../../models/mqtt/MqttHost';
import UseMqttConnection from '../../../hooks/mqtt/UseMqttConnection';
import './MqttConnection.css'
import EventMessage from '../../../components/message/EventMessage';
import FormInput from '../../../components/forminput/FormInput';

const MqttConnection: React.FC = () => {
    const [buttonText, setButtonText] = useState<string>("Test connection");
    const [showMessage, setShowMessage] = useState<boolean>(false);
    // const [options, setOptions] = useState<MqttOptions>({clientId: "", username: "", password: ""});
    const [style, setStyle] = useState<Object>();
    const [values, setValues] = useState<MqttHost | any>({
        host: "",
        port: "",
        clientId: "",
        username: "",
        password: ""
    });

    const { mqttStatus, mqttConnect } = UseMqttConnection(values);

    useEffect(() => {
        if (mqttStatus?.status === "Connected") {
            setStyle({
                backgroundColor: '#41af8c'
            });
            setButtonText("Connected");
        } else if (mqttStatus?.status === "Offline") {
            setStyle({
                backgroundColor: 'salmon'
            });
            setShowMessage(true)
            setButtonText("Not connected");
        } else if (mqttStatus?.status === "Connecting") {
            setStyle({
                backgroundColor: '#d5ae48'
            });
            setButtonText("Connecting");
        }

    }, [mqttStatus?.status])

    const inputs = [
        {
            id: 1,
            name: "host",
            type: "text",
            placeholder: "Host",
            pattern: "[0-9.]{1,20}$",
            errorMessage: "It should be a valid email address!",
            label: "Host",
        },
        {
            id: 2,
            name: "port",
            type: "number",
            placeholder: "Port",
            errorMessage: "Password should be 8-20 characters and include atleast 1 letter, 1 number and 1 special character!",
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
                <EventMessage
                    showMessage= {showMessage}
                    setShowMessage= {setShowMessage}
                    messageTime={5000}
                    message={mqttStatus?.status}
                    isError={true} />
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