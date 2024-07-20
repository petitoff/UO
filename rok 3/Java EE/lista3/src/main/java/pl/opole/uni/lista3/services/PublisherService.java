package pl.opole.uni.lista3.services;

import org.springframework.stereotype.Service;
import pl.opole.uni.lista3.models.Publisher;
import pl.opole.uni.lista3.repos.PublisherRepository;

@Service
public class PublisherService extends GenericService<Publisher, Long> {
    public PublisherService(PublisherRepository repository) {
        super(repository);
    }
}