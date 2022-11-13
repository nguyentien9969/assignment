import React from "react";
import BookDatatable from "../../DataTable/BookDatatable";
import FormDialog from "../../components/Popup";
import BookForm from "../../components/Books/BookForm"
require("es6-promise").polyfill();

const BookPosts = () => {
  return (
    <div>
      <FormDialog title="add book here">
        <BookForm />
      </FormDialog>
      <BookDatatable />
    </div>
  );
};

export default BookPosts;
