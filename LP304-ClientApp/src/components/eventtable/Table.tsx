import "./Table.css"
import "../forminput/FormInput.css"
import arrow from "../../assets/icons/arrow-down-sign-to-navigate.png"
import { useState } from "react"
import Pagination from "../pagination/Pagination"

type Props = {
    events: any[]
}

const Table: React.FC<Props> = ({ events }) => {
    const [eventss, setEventss] = useState<any[]>(events);
    const [displayedData, setDisplayedData] = useState<any[]>([]);
    const [sortOrder, setSortOrder] = useState("ASC")
    const [itemsPerPage, setItemsPerPage] = useState<number>(5)
    const allPages: number = Math.ceil(eventss.length / itemsPerPage);
    var columns: string[] = [];

    if (events.length !== 0) {
        columns = Object.getOwnPropertyNames(events[0]);
    }

    const sorting = (column: string) => {
        if (sortOrder === "ASC") {
            const sorted = [...eventss].sort((a, b) =>
                a[(column)] > b[(column)] ? 1 : -1
            )
            setEventss(sorted)
            setSortOrder("DSC")
        }
        if (sortOrder === "DSC") {
            const sorted = [...eventss].sort((a, b) =>
                a[(column)] < b[(column)] ? 1 : -1
            )
            setEventss(sorted)
            setSortOrder("ASC")
        }
    }

    const onPageChange = (page: number = 1) => {
        const startItem = (page - 1) * itemsPerPage;
        const endItem = page * itemsPerPage;
        setDisplayedData(eventss.slice(startItem, endItem))
    }

    const handleChange = (e: any) => {
        setItemsPerPage(e.target.value)
    }

    return (
        <div>

            <table className="table-container">
                {eventss?.length ? (
                    <thead>
                        <tr className="table-columns">
                            {columns.map(column =>
                                <th key={column} onClick={() => sorting(column)}>
                                    {column}
                                    <img src={arrow} alt="Sort" />
                                </th>
                            )}
                        </tr>
                    </thead>
                ) : <thead><tr><th>No data to be shown</th></tr></thead>}
                <tbody>
                    {displayedData.map((event: any) =>
                        <tr className="table-rows" key={event.id}>
                            {columns.map((column) =>
                                <td key={column}>{event[column]}</td>
                            )}
                        </tr>
                    )}
                </tbody>
            </table>

            <select onChange={(e) => handleChange(e)}>
                <option value="5">5</option>
                <option value="10">10</option>
                <option value="20">20</option>
                <option value="50">50</option>
                <option value="100">100</option>
            </select>
            <Pagination allPagesNumber={allPages} itemsNumber={eventss.length} itemsPerPage={itemsPerPage} pageChange={onPageChange} />
        </div>
    );
}

export default Table;