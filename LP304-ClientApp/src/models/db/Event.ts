import internal from "stream";

export default interface Event {
    id: number,
    startTime: string,
    endTime: string,
    duration: number,
    reason: string,
    eventStatusId: number
}