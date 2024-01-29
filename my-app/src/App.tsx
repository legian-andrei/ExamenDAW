import { BrowserRouter, Route, Routes } from "react-router-dom";
import BooksTable from "./BooksTable.tsx";
import React from "react";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<BooksTable />} />
      </Routes>
    </BrowserRouter>
  );
}

export { App };