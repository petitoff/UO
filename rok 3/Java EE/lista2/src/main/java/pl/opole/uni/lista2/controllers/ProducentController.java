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
    @GetMapping("/ProducentWithmenJPQL")
    public List<Producent> getNameWithmenJPQL() {return repo.findContainmenJPQL();}
    @GetMapping("/ProducentWithmenSQL")
    public List<Producent> getNameWithmenSQL() {return repo.findContainmenSQL();}

    @GetMapping("/ProducentWithoutonJPQL")
    public List<Producent> getNameWithoutonJPQL() {return repo.findContainNotonJPQL();}
    @GetMapping("/ProducentWithoutonSQL")
    public List<Producent> getNameWithoutonSQL() {return repo.findContainNotonSQL();}
}
