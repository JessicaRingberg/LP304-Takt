import Area from "./Area";
import User from "./User";

interface Company {
    id: number,
    name: string,
    users: User[],
    areas: Area[];
}

export default Company;