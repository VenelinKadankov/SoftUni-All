from project.bookstore import Bookstore

bookstore = Bookstore(5)

bookstore.receive_book('Title', 4)
print(str(bookstore))
