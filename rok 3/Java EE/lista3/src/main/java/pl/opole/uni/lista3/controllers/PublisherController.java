package pl.opole.uni.lista3.controllers;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.opole.uni.lista3.models.Publisher;
import pl.opole.uni.lista3.services.PublisherService;

@RestController
@RequestMapping("/publishers")
public class PublisherController extends GenericController<Publisher, Long> {
    public PublisherController(PublisherService service) {
        super(service);
    }
}