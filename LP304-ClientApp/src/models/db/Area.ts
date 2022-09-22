import Station from "./Stations";

export default interface Area {
    id: number,
    name: string,
    stations: Station[]
}