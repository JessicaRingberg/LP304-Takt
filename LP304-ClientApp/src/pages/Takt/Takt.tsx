import './Takt.css';
import { useEffect, useState } from "react";
import Company from '../../models/Company';
import CompanyList from '../../components/companyList/CompanyList';
import UseFetch from '../../hooks/usefetch/UseFetch';
import LoadingSpinner from '../../components/loadingspinner/LoadingSpinner';

function Home() {
    const {data : companies , isPending, error} = UseFetch('https://localhost:7112/api/Company')

    return (
        <div className="main-content">
            <div>
                { error && <p className='error'> {error} </p>}
                {isPending && <LoadingSpinner />}
                {companies && <CompanyList companies={companies} />}
            </div>

        </div>
    );
}

export default Home;