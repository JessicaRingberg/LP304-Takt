import { useEffect, useState } from "react";
import MqttStatus from "../../models/mqtt/MqttStatus";
import MqttHost from "../../models/mqtt/MqttHost";

const UseFetch = (mqttHost: MqttHost) => {

    
    var mqtt = require('mqtt/dist/mqtt')

    const [client, setClient] = useState<any>();
    const [isSub, setIsSub] = useState<boolean>(false);
    const [mqttStatus, setMqttStatus] = useState<MqttStatus>();

    const mqttConnect = () => {
        console.log(mqttHost)
        setMqttStatus({ status: 'Connecting' });
        setClient(mqtt.connect('ws://' + mqttHost.host +  ":" + mqttHost.port ));
    };

    const mqttDisconnect = () => {
        if (client) {
            client.end(() => {
                setMqttStatus({status: 'Connect'});
            });
        }
    }

    const mqttPublish = (context : any) => {
        if (client) {
          const { topic, qos, payload } = context;
          client.publish(topic, payload, { qos }, (error: any) => {
            if (error) {
              console.log('Publish error: ', error);
            }
          });
        }
      }
    
      const mqttSub = (subscription : any) => {
        if (client) {
          const { topic, qos } = subscription;
          client.subscribe(topic, { qos }, (error: any) => {
            if (error) {
              console.log('Subscribe to topics error', error)
              return
            }
            setIsSub(true)
          });
        }
      };
    
      const mqttUnSub = (subscription : any) => {
        if (client) {
          const { topic } = subscription;
          client.unsubscribe(topic, (error: any) => {
            if (error) {
              console.log('Unsubscribe error', error)
              return
            }
            setIsSub(false);
          });
        }
      };

    useEffect(() => {

        if (client) {
            client.on('connect', () => {
                setMqttStatus({ status: "Connected" })
            });
            client.on('error', (err: any) => {
                setMqttStatus({ status: "Connection error: " + err.message });
                client.end();
            });
            client.on('reconnect', () => {
                setMqttStatus({ status: "Reconnecting" });
              });
            client.on('offline', () => {
                setMqttStatus({ status: "Offline" });
                client.end();
                return
            });
            client.on('message', (topic: string, message: string) => {
                const payload = { topic, message: message.toString() };
                setMqttStatus({ status: "message", payload: payload })
            });
        }
    }, [client]);

    return { mqttStatus, mqttConnect, mqttDisconnect, mqttPublish, mqttSub, mqttUnSub, isSub}
}

export default UseFetch;