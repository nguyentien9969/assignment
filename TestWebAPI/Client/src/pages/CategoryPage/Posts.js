import React from "react";
import CategoryDatatable from "../../DataTable/CategoryDatatable";
import FormDialog from "../../components/Popup";

import CategoryForm from "../../components/Categorys/CategoryForm";
require("es6-promise").polyfill();

const CategoryPosts = () => {
  return (
    <div>
      <FormDialog title="add book here">
        <CategoryForm />
      </FormDialog>
      <CategoryDatatable />
    </div>
  );
};

export default CategoryPosts;
