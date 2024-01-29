export type BookType = {
  id: number;
  title: string;
  authors: AuthorType[];
  publisher: PublisherType;
};

export type AuthorType = {
  id: number;
  name: string;
};

export type PublisherType = {
  id: number;
  name: string;
};

export const emptyBookType: BookType = {
  id: 0,
  title: "",
  authors: [],
  publisher: { id: 0, name: "" },
};