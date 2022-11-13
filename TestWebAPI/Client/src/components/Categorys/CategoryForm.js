import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import {useFormik} from "formik"
import * as Yup from "yup"
import { addBook } from "../../services/service";

const styles = makeStyles({
  form: {
    backgroundColor: "#4f25f7",
    padding: "50px",
    borderRadius: "10px",
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    boxShadow: "5px 5px 15px -1px rgba(0,0,0,0.75)",
    color: "white",
  },
  formContainer: {
    height: "50vh",
    padding: "20px",
    display: "flex",
    flexDirection: "column",
    justifyContent: "center",
    alignItems: "center",
  },
  formInput: {
    width: "100%",
    margin: "10px",
    height: "40px",
    borderRadius: "5px",
    border: "1px solid gray",
    padding: "5px",
    fontFamily: "'Roboto', sans-serif",
  },
  formSubmit: {
    width: "50%",
    padding: "10px",
    borderRadius: "5px",
    color: "#4f25f7",
    backgroundColor: "#fff",
    border: "none",
    cursor: "pointer",
  },
  formMarketing: {
    display: "flex",
    margin: "20px",
    alignItems: "center",
  },
  validationText: {
    margin: "0px",
    fontSize: "0.7em"
  },
  validContainer: {
    height: "20px"
  }
});


const CategoryForm = () => {
  const formik = useFormik({
    initialValues:{
      name: "",
      description: "",
      category :"",
      rememberCheck: true,
    },
    validationSchema: Yup.object({
        name: Yup.string()
        .min(10,"Must be at least 10 characters !").required("Required !"),
        description: Yup.string()
        .min(10, "Must be at least 10 characters !").required("Required !"),
        category: Yup.string()
        .min(10,"Must be at least 10 characters !").required("Required !"),
    }),
    onSubmit: (value) => { 
      console.log("OK")
      addBook(value).then((respone)=>{
        console.log("Ok",respone);
      });
    }
});

  const classes = styles();

  return (
    <div className={classes.formContainer}>
      <form className={classes.form} onSubmit={formik.handleSubmit}>
        <input
          type="name"
          placeholder="name"
          className={classes.formInput}
          name="name"
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
          value={formik.values.name}
        />

        <div className={classes.validContainer}>
        {formik.touched.name && formik.errors.name ? <p className={classes.validationText}>{formik.errors.name}</p> : null}
        </div>

        <input
          type="description"
          placeholder="description"
          className={classes.formInput}
          name="description"
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
          value={formik.values.description}
        />

        <div className={classes.validContainer}>
        {formik.touched.description && formik.errors.description ? <p className={classes.validationText}>{formik.errors.description}</p> : null}
        </div>

        <input
          type="category"
          placeholder="category"
          className={classes.formInput}
          name="category"
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
          value={formik.values.category}
        />

        <div className={classes.validContainer}>
        {formik.touched.category && formik.errors.category ? <p className={classes.validationText}>{formik.errors.category}</p> : null}
        </div>

        <div className={classes.formMarketing}>
          <input
            id="okayToRemember"
            type="checkbox"
            name="rememberCheck"
            onChange={formik.handleChange}
            value={formik.values.rememberCheck}
          />
          <label htmlFor="okayToRemember">Remember me</label>
        </div>
        <button type="submit" className={classes.formSubmit}>Submit</button>
      </form>
    </div>
  );
};

export default CategoryForm;
