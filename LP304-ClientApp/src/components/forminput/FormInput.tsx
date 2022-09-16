import { useState } from "react";
import "./FormInput.css"

function FormInput(props: any) {
    const [focused, setFocused] = useState<boolean>(false);
    const { label, errorMessage, onChange, id, ...inputProps } = props;

    const handleFocus = (e: React.ChangeEvent<HTMLInputElement>) => {
        setFocused(true);
    }

    return (
        <div className="formInput">
            { inputProps.type !== "checkbox" && <label>{label}</label>}
            <input
                {...inputProps}
                id={id} 
                onChange={onChange} 
                onBlur={handleFocus} 
                onFocus={() => inputProps.name === "confirmPassword" && setFocused(true)}
                focused={focused.toString()}
                />
                { inputProps.type === "checkbox" && <label htmlFor={id}>{label}</label>}
            <span>{errorMessage}</span>
        </div>
    );
}

export default FormInput;