package pl.opole.uni.lista3.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.opole.uni.lista3.model.Autor;
import pl.opole.uni.lista3.model.Ksiazka;

import java.util.List;

@Repository
public interface KsiazkaRepo extends JpaRepository<Ksiazka,Integer> {
    List<Ksiazka>findByTytulEquals(String title);
}
