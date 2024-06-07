package pl.uni.opole.lista5.service;

import jakarta.persistence.EntityNotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import pl.uni.opole.lista5.model.Autor;
import pl.uni.opole.lista5.model.Ksiazka;
import pl.uni.opole.lista5.repo.KsiazkaRepo;

import java.util.List;

@Service
public class KsiazkaService {
    @Autowired
    private KsiazkaRepo repo;

    public List<Ksiazka> getAllKsiazka()
    {
        return repo.findAll();
    }

    public List<Ksiazka> getKsiazkaByTitle(String name)
    {
        return repo.findByTytulEquals(name);
    }


    public Ksiazka addKsiazka(Ksiazka newKsiazka)
    {
        Ksiazka savedKsiazka = repo.save(newKsiazka);
        return savedKsiazka;
    }

    public Ksiazka editKsiazka(Integer id,Ksiazka ksiazka)
    {
        Ksiazka editedKsiazka = repo.findById(id).get();

        editedKsiazka.setAutors(ksiazka.getAutors());
        editedKsiazka.setCena(ksiazka.getCena());
        editedKsiazka.setOpis(ksiazka.getOpis());
        editedKsiazka.setTytul(ksiazka.getTytul());
        editedKsiazka.setRodzajKsiazki(ksiazka.getRodzajKsiazki());
        editedKsiazka.setSprzedazList(ksiazka.getSprzedazList());
        return repo.save(editedKsiazka);
    }

    public Boolean deletedKsiazka(Integer id)
    {
        repo.deleteById(id);

        try
        {
            if(repo.findById(id) == null)
                return true;
            else
                return false;
        }
        catch(EntityNotFoundException e)
        {
            return false;
        }
    }
}
