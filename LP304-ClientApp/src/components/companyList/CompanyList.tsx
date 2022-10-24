import { NavLink } from "react-router-dom";
import Company from "../../models/db/Company";
import './CompanyList.css';
import remove from '../../assets/icons/remove.png'
import { useDelete } from "../../hooks/db/useDelete";

type Props = {
    companies: Company[]
    setUpdateData: React.Dispatch<React.SetStateAction<boolean>>
}

function CompanyList({ companies, setUpdateData }: Props) {
    const { deleteEntity } = useDelete()

    return (
        <div className="company-list">
            {companies.map(company =>
                <ul className="company-preview" key={company.id}>
                    <NavLink to={`/settings/companies/${company.id}`} className="company-field" >
                        <li><h3>{company.name}</h3></li>
                    </NavLink>
                    <img src={remove} alt="remove-company" className="remove-icon" onClick={() => {
                        deleteEntity('https://localhost:7112/api/Company/' + company.id);
                        setUpdateData(true) 
                        }}/>
                </ul>
            )}
        </div>
    );
}

export default CompanyList;