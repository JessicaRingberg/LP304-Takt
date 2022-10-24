import React, { useEffect } from 'react';
import Table from '../../components/eventtable/Table';
import LoadingSpinner from '../../components/loadingspinner/LoadingSpinner';
import useFetch from '../../hooks/db/useFetch';
import "./Events.css";

const Events: React.FC = () => {
  const { fetchEntity, data: events, isPending, error } = useFetch()

  useEffect(() => {
    fetchEntity('https://localhost:7112/api/Event')
  }, [fetchEntity])

  return (
    <main>
      <div className="main-content">
        <div className="main-header">
          <h2>Events</h2>
          <p>A table of all the events is shown below. You can sort by column and filter on specific value</p>
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



export default Events;