import React from 'react'
import { Route, Routes } from 'react-router-dom'
import './index.css'
import Navbar from './components/Navbar'
import Posts from './pages/PostPage/Posts'
import Login from './pages/LoginPage/Login'
import HomePage from './pages/Home'
import PostDetail from './pages/PostPage/PostDetail'

function App() {
  return (
    <div className="App">
      <div className="mb-5">
        <Navbar />
      </div>
      <Routes>
        <Route exact path="/" element={<HomePage />} />
        <Route path="/posts" element={<Posts />} />
        <Route path="/profile" element={<PostDetail />} />
        <Route path="/login" element={<Login />} />
      </Routes>
    </div>
  )
}

export default App
