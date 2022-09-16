export default interface  MqttPayload{
    topic: string,
    message: string
    payload?: Object | string
}