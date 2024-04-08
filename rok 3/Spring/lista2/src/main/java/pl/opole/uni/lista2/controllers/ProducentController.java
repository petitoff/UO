package pl.opole.uni.lista2.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.opole.uni.lista2.model.Producent;
import pl.opole.uni.lista2.repo.ProducentRepo;

import java.util.List;

@RestController
public class ProducentController {
    @Autowired
    private ProducentRepo repo;
    @GetMapping("/ProducentWithmen")
    public List<Producent> getNameWithmen() {return repo.findByNazwaContaining("men");}

    @GetMapping("/ProducentWithouton")
    public List<Producent> getNameWithouton() {return repo.findByNazwaNotContaining("on");}
}
