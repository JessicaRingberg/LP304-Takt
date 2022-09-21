import { useParams } from "react-router-dom";

const AreaSettings: React.FC = () => {
    const { id } = useParams();

    
    return (
        <main>
            <div className="main-content">
                <div className="main-header">
                    <h2>Takt</h2>
                    <p>Here you can configure and start the Takt {id}</p>
                </div>
            </div>
        </main>
    );
}

export default AreaSettings;