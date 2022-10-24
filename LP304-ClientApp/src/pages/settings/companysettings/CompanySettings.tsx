import './CompanySettings.css'
import CompanyList from '../../../components/companyList/CompanyList';
import useFetch from '../../../hooks/db/useFetch';
import LoadingSpinner from '../../../components/loadingspinner/LoadingSpinner';
import { useState, useEffect } from 'react'
import FormInput from '../../../components/forminput/FormInput';
import { usePost } from '../../../hooks/db/usePost';

function CompanySettings() {
    const [updateData , setUpdateData] = useState<boolean>(false);
    const { fetchEntity , data: companies, isPending, error: fetchError } = useFetch()
    const { post } = usePost('https://localhost:7112/api/Company')

    const [values, setValues] = useState<any>({
        name: ""
    });

    const inputs = [
        {
            id: 1,
            name: "name",
            type: "text",
            placeholder: "Name",
            pattern: "[a-zA-Z0-9 ]{1,20}$",
            errorMessage: "You need to write a name with maximum of 20 characters!",
            label: "Company name",
        }
    ]
    
    useEffect(() => {         
        fetchEntity('https://localhost:7112/api/Company')
        setUpdateData(false)
    }, [updateData, fetchEntity ])

    const handleSubmit = async (e: any) => {
        e.preventDefault();
        post(values);
        setUpdateData(true)
        setValues({ name: "" })
    }

    const onChange = (e: any) => {
        setValues({ ...values, [e.target.name]: e.target.value })
    }

    return (
        <main>
            <div className="main-content">
                <div className="main-header">
                    <h2>Company settings</h2>
                    <p>Here you can see all the companies. Add, edit or delete companies.</p>
                </div>

                <div className='company-content'>
                    <div>
                        <section className='loading-container'>
                            {fetchError && <p> {fetchError} </p>}
                            {isPending && <LoadingSpinner />}
                        </section>
                        {companies && <CompanyList companies={companies} setUpdateData={setUpdateData} />}
                    </div>
                    <div className="add-company">
                        <form onSubmit={handleSubmit}>
                            <div className="logo"></div>
                            <div>
                                <h2>Add company</h2>
                                {inputs.map(input => (
                                    <FormInput key={input.id} {...input} value={values[input.name]} onChange={onChange} />
                                ))}
                                <button disabled={isPending}>Add</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </main>
    );
}

export default CompanySettings;