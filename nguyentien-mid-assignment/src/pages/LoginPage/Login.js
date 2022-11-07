import React from 'react'

const Login = () => {
  const [FormData, SetFormData] = React.useState({
    email: '',
    password: '',
  })

  function handleChange(event) {
    const { name, value } = event.target
    SetFormData((prev) => ({
      ...prev,
      [name]: value,
    }))
  }

  function handleSubmit(event) {
    event.preventDefault()
  }

  return (
    <div>
      <form className="form" onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="email"
          name="email"
          className="form--input"
          onChange={handleChange}
          value={FormData.email}
        />
        <input
          type="text"
          placeholder="password"
          name="password"
          className="form--input"
          onChange={handleChange}
          value={FormData.password}
        />
        <button className="form--submit">Login </button>
      </form>
    </div>
  )
}

export default Login
