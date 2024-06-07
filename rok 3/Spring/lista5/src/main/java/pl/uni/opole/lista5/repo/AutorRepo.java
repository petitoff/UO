package pl.uni.opole.lista5.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.uni.opole.lista5.model.Autor;

@Repository
public interface AutorRepo extends JpaRepository<Autor,Integer> {
}
