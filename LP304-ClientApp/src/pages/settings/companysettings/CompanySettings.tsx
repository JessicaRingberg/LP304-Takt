import './CompanySettings.css'
import Company from '../../../models/Company';
import CompanyList from '../../../components/companyList/CompanyList';
import UseFetch from '../../../hooks/db/usefetch/UseFetch';
import LoadingSpinner from '../../../components/loadingspinner/LoadingSpinner';

function CompanySettings() {
    const { data: companies, isPending, error } = UseFetch('https://localhost:7112/api/Company')

    return ( 
        <main>
        <div className="main-content">
            <section>
                {error && <p className='error'> {error} </p>}
                {isPending && <LoadingSpinner />}
            </section>
            {companies && <CompanyList companies={companies} />}
        </div>
    </main>
     );
}

export default CompanySettings;