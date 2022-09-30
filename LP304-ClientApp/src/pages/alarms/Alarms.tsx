import Table from "../../components/eventtable/Table";
import LoadingSpinner from "../../components/loadingspinner/LoadingSpinner";
import useFetch from "../../hooks/db/useFetch";

function Alarms() {
    const { data: events, isPending, error } = useFetch('https://localhost:7112/api/Alarm')

    return (
        <main>
            <div className="main-content">
                <div className="main-header">
                    <h2>Alarms</h2>
                    <p>A table of all the alarms is shown below. You can sort by column and filter on specific value</p>
                </div>
                <div className="table-content">
                    <section className='loading-container'>
                        {error && <p> {error} </p>}
                        {isPending && <LoadingSpinner />}
                    </section>
                    {events && <Table events={events} />}
                </div>
            </div>
        </main>
    );
}

export default Alarms;