package pl.opole.uni.lista2.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.opole.uni.lista2.model.Dzial;
import pl.opole.uni.lista2.model.Producent;
import pl.opole.uni.lista2.repo.DzialRepo;
import pl.opole.uni.lista2.repo.ProducentRepo;

import java.util.List;

@RestController
public class DzialController {
    @Autowired
    private DzialRepo repo;
    @GetMapping("/DzialEnding")
    public List<Dzial> getNameEnding() {return repo.findByNazwaEndingWith("ing");}

}
