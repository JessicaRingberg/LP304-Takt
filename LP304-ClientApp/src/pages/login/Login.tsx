import { useState } from 'react';
import { Cookies } from 'react-cookie';
import { useNavigate } from 'react-router-dom';
import FormInput from '../../components/forminput/FormInput';
import EventMessage from '../../components/message/EventMessage';
import ILogin from '../../models/db/Login';
import Input from '../../models/Input';
import './Login.css';

function Login() {
  const navigate = useNavigate();
  const [loginFailed, setLoginFailed] = useState<boolean>(false);
  const [values, setValues] = useState<Input | any>({
    firstName: "",
    lastName: "",
    email: "",
    password: "",
    confirmPassword: ""
  });

  const inputs = [
    {
      id: 1,
      name: "email",
      type: "email",
      placeholder: "Email",
      errorMessage: "It should be a valid email address!",
      label: "Email",
    },
    {
      id: 2,
      name: "password",
      type: "password",
      placeholder: "Password",
      pattern: "{2,}",
      errorMessage: "You need to enter a password",
      label: "Password"
    }
  ]

  const tryLogin = (login: ILogin) => {
    fetch('https://localhost:7112/api/User/Login', {
      method: 'POST',
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(login)
    }).then(res => {
      if (!res.ok) {
        throw Error('Could not fetch the data for that resource')
      }

      return res.json()
    }).then(data => {
      var cookie = new Cookies();
      cookie.set("token", data.data)      
      navigate("/");
    }).catch(err => {
      if (err.name === "AbortError") {

      } else {
        setLoginFailed(true)
      }
    })
  }

  const handleSubmit = async (e: any) => {
    e.preventDefault();
    const login: ILogin = { email: values.email, password: values.password }
    await tryLogin(login)
  }

  const onChange = (e: any) => {
    setValues({ ...values, [e.target.name]: e.target.value })
    setLoginFailed(false);
  }

  return (
    <div className="login">
                {loginFailed &&
            <EventMessage
              showMessage={loginFailed}
              setShowMessage={setLoginFailed}
              messageTime={5000}
              message={"Email or password is incorrect, Please try again."}
              isError={true} />
          }
      <div className="custom-shape-divider-top-1662895326">
        <svg data-name="Layer 1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 1200 120" preserveAspectRatio="none">
          <path d="M0,0V46.29c47.79,22.2,103.59,32.17,158,28,70.36-5.37,136.33-33.31,206.8-37.5C438.64,32.43,512.34,53.67,583,72.05c69.27,18,138.3,24.88,209.4,13.08,36.15-6,69.85-17.84,104.45-29.34C989.49,25,1113-14.29,1200,52.47V0Z" opacity=".25" className="shape-fill"></path>
          <path d="M0,0V15.81C13,36.92,27.64,56.86,47.69,72.05,99.41,111.27,165,111,224.58,91.58c31.15-10.15,60.09-26.07,89.67-39.8,40.92-19,84.73-46,130.83-49.67,36.26-2.85,70.9,9.42,98.6,31.56,31.77,25.39,62.32,62,103.63,73,40.44,10.79,81.35-6.69,119.13-24.28s75.16-39,116.92-43.05c59.73-5.85,113.28,22.88,168.9,38.84,30.2,8.66,59,6.17,87.09-7.5,22.43-10.89,48-26.93,60.65-49.24V0Z" opacity=".5" className="shape-fill"></path>
          <path d="M0,0V5.63C149.93,59,314.09,71.32,475.83,42.57c43-7.64,84.23-20.12,127.61-26.46,59-8.63,112.48,12.24,165.56,35.4C827.93,77.22,886,95.24,951.2,90c86.53-7,172.46-45.71,248.8-84.81V0Z" className="shape-fill"></path>
        </svg>
      </div>

      <form onSubmit={handleSubmit}>
        <div className="logo"></div>
        <div>
          <h2>Login to account</h2>
          {inputs.map(input => (
            <FormInput key={input.id} {...input} value={values[input.name]} onChange={onChange} />
          ))}
          <button>Login</button>
          <p>forgot password? <a href="tets">reset it here</a></p>
        </div>
      </form>

    </div>
  );
}

export default Login;
