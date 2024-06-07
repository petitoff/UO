package pl.uni.opole.lista5.service;

import jakarta.persistence.EntityNotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import pl.uni.opole.lista5.model.Autor;
import pl.uni.opole.lista5.repo.AutorRepo;

import java.util.List;

@Service
public class AutorService {
    @Autowired
    private AutorRepo repo;

    public List<Autor> getAllAutors(){
        return repo.findAll();
    }

    public Autor addAutor(Autor newAutor)
    {
        Autor savedAutor = repo.save(newAutor);
        return savedAutor;
    }

    public Autor editAutor(Integer id,Autor autor)
    {
        Autor editedAutor = repo.findById(id).get();

        editedAutor.setImie(autor.getImie());
        editedAutor.setNazwisko(autor.getNazwisko());
        editedAutor.setKsiazki(autor.getKsiazki());
        return repo.save(editedAutor);
    }

    public Boolean deletedAutor(Integer id)
    {
        repo.deleteById(id);

        try
        {
            if (repo.getById(id) != null)
                return false;
            else
                return true;
        }
        catch(EntityNotFoundException e)
        {
            return true;
        }
    }
}
