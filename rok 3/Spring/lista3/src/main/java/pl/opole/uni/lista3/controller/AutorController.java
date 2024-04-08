package pl.opole.uni.lista3.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import pl.opole.uni.lista3.model.Autor;
import pl.opole.uni.lista3.service.AutorService;

import java.util.List;

@RestController
public class AutorController {
    @Autowired
    private AutorService service;

    @GetMapping("/selectAutor")
    public List<Autor> getAutors(String name)
    {
        return service.getAllAutors();
    }

    @PostMapping("/insertAutor")
    public Autor addAutor(@RequestBody Autor newAutor)
    {
        return service.addAutor(newAutor);
    }

    @PutMapping("/updateAutor")
    public Autor editAutor(@RequestParam(required = true) Integer id, @RequestBody Autor newAutor)
    {
        return service.editAutor(id,newAutor);
    }

    @DeleteMapping("deleteAutor")
    public Boolean deletedAutor(@RequestParam(required = true) Integer id)
    {
        return service.deletedAutor(id);
    }
}
