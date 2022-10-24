import { useEffect, useState } from "react";
import { useMessageContext } from "../../hooks/db/useMessageContext";
import "./Message.css"

interface Style {
    color: string
}

const Message: React.FC = () => {
    const messageTime: number = 4000;
    const { state } = useMessageContext();
    const [style, setStyle] = useState<Style>();
    const [className, setClassName] = useState<string>("");

    useEffect(() => {
        if (state.messages.message) {
            if (state.messages.error) {
                setStyle({ color: "red" })
            } else {
                setStyle({ color: "black" })
            }

            setClassName("error-message slide-in")

            const timer = setTimeout(() => {
                setClassName("error-message slide-out")
            }, messageTime);
            return () => clearTimeout(timer);
        }

    }, [state]);

    return (
        <div className="error-message-container">
            <div className={className}>
                <p style={style}>{state.messages.message}</p>
            </div>
        </div>
    );
}

export default Message;