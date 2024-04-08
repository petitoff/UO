package pl.opole.uni.lista2.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.opole.uni.lista2.model.Urzadzenie;
import pl.opole.uni.lista2.repo.UrzadzenieRepo;

import java.util.List;

@RestController
public class UrzadzenieController {
    @Autowired
    private UrzadzenieRepo repo;
    @GetMapping("/Drukarki")
    public List<Urzadzenie> getPrinter() {return repo.findByRodzajUrzadzeniaRodzajUrzadzeniaIDEquals(1);}
    @GetMapping("/Producentniesony")
    public List<Urzadzenie> getNotSony() {return repo.findByProducentProducentIDNot(2);}
}
