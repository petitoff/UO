package pl.opole.uni.lista2.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.opole.uni.lista2.model.RodzajUrzadzenia;
import pl.opole.uni.lista2.repo.RodzajUrzadzeniaRepo;

import java.util.List;

@RestController
public class RodzajUrzadzeniaController{
    @Autowired
    private RodzajUrzadzeniaRepo repo;
    @GetMapping("/RodzajNazwaDJPQL")
    public List<RodzajUrzadzenia> getNameStartWithdJPQL()
    {
        return repo.findTypeOnDJPQL();
    }
    @GetMapping("/RodzajNazwaDSQL")
    public List<RodzajUrzadzenia> getNameStartWithdSQL()
    {
        return repo.findTypeOnDSQL();
    }

}