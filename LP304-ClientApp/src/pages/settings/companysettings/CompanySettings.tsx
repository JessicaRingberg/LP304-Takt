import './CompanySettings.css'
import CompanyList from '../../../components/companyList/CompanyList';
import useFetch from '../../../hooks/db/useFetch';
import LoadingSpinner from '../../../components/loadingspinner/LoadingSpinner';

function CompanySettings() {
    const { data: companies, isPending, error } = useFetch('https://localhost:7112/api/Company')

    return (
        <main>
            <div className="main-content">
                <div className="main-header">
                    <h2>Company settings</h2>
                    <p>Here you can see all the companies. Add, edit or delete companies.</p>
                </div>
                <section className='loading-container'>
                    {error && <p> {error} </p>}
                    {isPending && <LoadingSpinner />}
                </section>
                {companies && <CompanyList companies={companies} />}
            </div>
        </main>
    );
}

export default CompanySettings;