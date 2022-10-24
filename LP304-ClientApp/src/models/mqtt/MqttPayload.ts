export default interface  MqttPayload{
    topic: string,
    message: any
    payload?: Object | string
}