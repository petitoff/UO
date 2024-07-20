package pl.opole.uni.lista3.services;

import org.springframework.stereotype.Service;
import pl.opole.uni.lista3.models.Author;
import pl.opole.uni.lista3.repos.AuthorRepository;

@Service
public class AuthorService extends GenericService<Author, Long> {
    public AuthorService(AuthorRepository repository) {
        super(repository);
    }
}