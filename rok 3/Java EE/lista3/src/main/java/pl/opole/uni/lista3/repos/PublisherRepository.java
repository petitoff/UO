package pl.opole.uni.lista3.repos;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.opole.uni.lista3.models.Publisher;

@Repository
public interface PublisherRepository extends JpaRepository<Publisher, Long> {}
