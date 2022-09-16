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
                    <li><h2>{company.name}</h2></li>
                    <li><p>{company.areas.map(area => area.name)}</p></li>
                    <li><p>{company.users.map(user => user.username)}</p></li>
                </ul>
            )}
        </div>
    );
}

export default CompanyList;