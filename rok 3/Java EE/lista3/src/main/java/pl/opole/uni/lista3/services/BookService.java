package pl.opole.uni.lista3.services;

import org.springframework.stereotype.Service;
import pl.opole.uni.lista3.models.Book;
import pl.opole.uni.lista3.repos.BookRepository;

@Service
public class BookService extends GenericService<Book, Long> {
    public BookService(BookRepository repository) {
        super(repository);
    }
}