import MqttPayload from "./MqttPayload";

export default interface MqttStatus {
    status: string,
    payload?: MqttPayload
}