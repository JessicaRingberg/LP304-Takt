import { useEffect, useState } from "react";
import "./EventMessage.css"

interface Props {
    showMessage: boolean,
    setShowMessage: React.Dispatch<React.SetStateAction<boolean>>,
    messageTime: number,
    message: string | undefined,
    isError: boolean
}

interface Style {
    color: string
}

const EventMessage: React.FC<Props> = ({ showMessage, setShowMessage, messageTime , message, isError }) => {
    const [style, setStyle] = useState<Style>();

    
    useEffect(() => {
        if(isError) {
            setStyle({ color: "red"})
        } else {
            setStyle({ color: "black"})
        }

        const timer = setTimeout(() => {
          setShowMessage(false)
        }, messageTime);
        return () => clearTimeout(timer);
      }, [showMessage, setShowMessage, isError, messageTime]);

    return (
        <div className="error-message-container">
             { showMessage && <div className="error-message slide-in">
                <p style={style}>{message}</p>
            </div> }
        </div>
     );
}

export default EventMessage;