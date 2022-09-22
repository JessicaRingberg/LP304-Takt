import Area from "./Area";
import User from "./User";

export default interface Company {
    id: number,
    name: string,
    users: User[],
    areas: Area[];
}