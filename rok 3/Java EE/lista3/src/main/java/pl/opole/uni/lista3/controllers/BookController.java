package pl.opole.uni.lista3.controllers;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.opole.uni.lista3.models.Book;
import pl.opole.uni.lista3.services.BookService;

@RestController
@RequestMapping("/books")
public class BookController extends GenericController<Book, Long> {
    public BookController(BookService service) {
        super(service);
    }
}