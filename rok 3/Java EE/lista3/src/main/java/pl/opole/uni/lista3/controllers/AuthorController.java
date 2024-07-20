package pl.opole.uni.lista3.controllers;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.opole.uni.lista3.models.Author;
import pl.opole.uni.lista3.services.AuthorService;

@RestController
@RequestMapping("/authors")
public class AuthorController extends GenericController<Author, Long> {
    public AuthorController(AuthorService service) {
        super(service);
    }
}
