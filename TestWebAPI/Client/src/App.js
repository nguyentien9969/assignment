import React from 'react';
import {
  createTheme,
  ThemeProvider,
} from "@material-ui/core/styles";
import { Routes, Route } from "react-router-dom";
import NavBar from "./components/NavBar.js";
import "./App.css";
import Footer from "./components/Footer";
import HomePage from "./pages/Home"
import ProfilePage from "./pages/ProfilePage/Profile"
import LoginPage from "./pages/LoginPage/Login"
import BookPostDetail from './pages/BookPage/PostDetail.js';
import BookPosts from './pages/BookPage/Posts.js';
import CategoryPosts from './pages/CategoryPage/Posts.js';
import CategoryPostDetail from './pages/CategoryPage/PostDetail.js';



const theme = createTheme({
  palette: {
    primary: {
      main: "#2e1667",
    },
    secondary: {
      main: "#c7d8ed",
    },
  },
  typography: {
    fontFamily: ["Roboto"],
    h4: {
      fontWeight: 600,
      fontSize: 28,
      lineHeight: "2rem",
    },
    h5: {
      fontWeight: 100,
      lineHeight: "2rem",
    },
  },
});

function App() {
  return (
    <div className="App">
      <ThemeProvider theme={theme}>
        <NavBar />
        <Routes>
        <Route exact path = "/" element={<HomePage/>} />
        <Route path = "/books" exact element={<BookPosts/>} />
        <Route path = "/book/:id" element={<BookPostDetail/>} />
        <Route path = "/categories" exact element={<CategoryPosts/>} />
        <Route path = "/category/:id" element={<CategoryPostDetail/>} />
        <Route path = "/profile" element={<ProfilePage/>}/>
        <Route path = "/login" element={<LoginPage/>} />
      </Routes>
        <div >
          <Footer />
        </div>
      </ThemeProvider>
      
    </div>
  );
}

export default App;
