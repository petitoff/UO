package pl.uni.opole.lista5.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import pl.uni.opole.lista5.model.Ksiazka;
import pl.uni.opole.lista5.service.KsiazkaService;

import java.util.List;

@RestController
public class KsiazkaController {
    @Autowired
    private KsiazkaService service;

    @GetMapping("/selectksiazki")
    public List<Ksiazka> getKsiazki(String title)
    {
        if(title==null)
        {
            return service.getAllKsiazka();
        }
        else
        {
            return service.getKsiazkaByTitle(title);
        }
    }

    @PostMapping("/insertksiazki")
    public Ksiazka addksiazka(@RequestBody Ksiazka newKsiazka)
    {
        return service.addKsiazka(newKsiazka);
    }

    @PutMapping("/updateksiazki")
    public Ksiazka editKsiazka(@RequestParam(required = true) Integer id, @RequestBody Ksiazka newKsiazka)
    {
        return service.editKsiazka(id,newKsiazka);
    }

    @DeleteMapping("/deleteksiazki")
    public Boolean deletedKsiazka(@RequestParam(required = true) Integer id)
    {
        return service.deletedKsiazka(id);
    }
}
