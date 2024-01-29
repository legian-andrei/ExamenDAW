import { useEffect, useState } from "react";
import { BookType } from "./books.types";
import axios from "axios";
import React from "react";

const StudentTable: React.FC = () => {
  const [booksList, setBooksList] = useState<BookType[]>([]);

  const tableHeaders = ["Id", "Titlu", "Autor(i)", "Editura"];

  const fetchData = async () => {
    try {
      const booksResponse = await axios.get("/BooksController/Index");

      if (!booksResponse?.data || booksResponse?.data?.error) {
        return;
      }

      const books: BookType[] = booksResponse?.data?.books;
      setBooksList(books);
    } catch (error) {
      console.error("Error fetching books:", error);
    }
  };

  useEffect(() => {
    fetchData();
  }, []);

  return (
    <table className="table">
      <thead>
        <tr>
          {tableHeaders.map((name, id) => (
            <th key={id}>{name}</th>
          ))}
        </tr>
      </thead>
      <tbody>
        {booksList?.map((book) => (
          <tr key={book?.id}>
            <td>{book?.id || ""}</td>
            <td>{book?.title || ""}</td>
            <td>
              {book?.authors.map((author, index) => (
                <span key={index}>{author.name} </span>
              )) || ""}
            </td>
            <td>{book?.publisher.name || ""}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default StudentTable;