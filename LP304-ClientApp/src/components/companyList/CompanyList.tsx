import { NavLink } from "react-router-dom";
import Company from "../../models/db/Company";
import './CompanyList.css';

type Props = {
    companies: Company[]
}

function CompanyList({ companies }: Props) {

    return (
        <div className="company-list">
            {companies.map(company =>
                <ul className="company-preview" key={company.id}>
                    <NavLink to={`/settings/companies/${company.id}`} >
                        <li><h2>{company.name}</h2></li>
                    </NavLink>
                </ul>
            )}
        </div>
    );
}

export default CompanyList;