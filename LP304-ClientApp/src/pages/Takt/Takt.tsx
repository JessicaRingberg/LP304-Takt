import './Takt.css';
import { useState } from "react";
import Input from '../../models/Input';
import FormInput from '../../components/forminput/FormInput';


 function Home() {
    
    const [isRepeatChecked, setIsRepeatChecked] = useState(false);
    const [values, setValues] = useState< any>({
        taktTime: ""
    });

    const inputs = [
        {
            id: 1,
            name: "taktTime",
            type: "number",
            placeholder: "Takt time",
            pattern: "[0-9]{1,5}$",
            errorMessage: "Number is required, can't be longer than 5 numbers and can't start with 0!",
            label: "Takt time",
        },
        {
            id: 2,
            name: "repeatTakt",
            type: "checkbox",
            placeholder: "Repeat takt",
            label: "Repeat takt"
        }
    ]

    const handleSubmit = (e: any) => {
        e.preventDefault();
    }

    const onChange = (e: any) => {
        setIsRepeatChecked(e.target.checked);
        setValues({ ...values, [e.target.name]: e.target.value })
    }

    return (
        <main>
            <div className="left-Content">

            </div>
            <div className="main-content">
                <div className="main-header">
                    <h2>Takt</h2>
                    <p>Here you can configure and start the Takt</p>
                </div>
                <div className="takt-content">
                <h2>Configure and start Takt</h2>
                    <form onSubmit={handleSubmit}>
                        <div>
                            {inputs.map(input => (
                                <FormInput key={input.id} {...input} value={values[input.name]} onChange={onChange} />
                            ))}
                            <button>Start cycle</button>
                        </div>
                    </form>
                </div>
            </div>
            <div className="right-content">

            </div>
        </main>
    );
}

export default Home;