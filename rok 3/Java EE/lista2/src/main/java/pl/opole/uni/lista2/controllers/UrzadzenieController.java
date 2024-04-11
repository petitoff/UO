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
    @GetMapping("/DrukarkiJPQL")
    public List<Urzadzenie> getPrinterJPQL() {return repo.findPrinterJPQL();}
    @GetMapping("/DrukarkiSQL")
    public List<Urzadzenie> getPrinterSQL() {return repo.findPrinterSQL();}
    @GetMapping("/ProducentniesonyJPQL")
    public List<Urzadzenie> getNotSonJPQL() {return repo.findNotSonyJPQL();}
    @GetMapping("/ProducentniesonySQL")
    public List<Urzadzenie> getNotSonSQL() {return repo.findNotSonySQL();}
}
