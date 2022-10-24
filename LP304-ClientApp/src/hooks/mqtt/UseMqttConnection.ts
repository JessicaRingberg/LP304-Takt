import { useEffect, useState } from "react";
import MqttStatus from "../../models/mqtt/MqttStatus";
import MqttHost from "../../models/mqtt/MqttHost";
import MqttPayload from "../../models/mqtt/MqttPayload";

const useMqttConnection = (mqttHost: MqttHost) => {
    var mqtt = require('mqtt/dist/mqtt')

    const [client, setClient] = useState<any>();
    const [mqttStatus, setMqttStatus] = useState<MqttStatus>();
    const [mqttPayload, setMqttPayload] = useState<MqttPayload>();

    const mqttConnect = () => {
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
            }
          });
        }
      }
    
      const mqttSub = (subscription : any) => {
        if (client) {
          const { topic, qos } = subscription;
          client.subscribe(topic, { qos }, (error: any) => {
            if (error) {
              return
            }
          });
        }
      };
    
      const mqttUnSub = (subscription : any) => {
        if (client) {
          const { topic } = subscription;
          client.unsubscribe(topic, (error: any) => {
            if (error) {
              return
            }
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
                setMqttPayload(payload)
            });
        }
    }, [client]);

    return { mqttStatus, mqttPayload , mqttConnect, mqttDisconnect, mqttPublish, mqttSub, mqttUnSub}
}

export default useMqttConnection;